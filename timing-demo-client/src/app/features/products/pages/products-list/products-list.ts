import { Component, inject, OnInit, signal } from '@angular/core';
import { ProductService } from '../../services/ProductService/product.service';
import { CategoryService } from '../../services/CategoryService/category.service';
import { Product } from '../../models/products.models';
import { Category } from '../../models/category.model';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { TimingService } from '../../../../Core/services/timing.service';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-products-list',
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './products-list.html',
  styleUrl: './products-list.css'
})
export class ProductsList implements OnInit {
  private readonly productsService = inject(ProductService)
  private readonly categoryService = inject(CategoryService)
  readonly timingService = inject(TimingService);
  private readonly formBuilder = inject(FormBuilder);

  readonly showCreateForm = signal(false);
  readonly showCreateCategoryForm = signal(false);
  readonly products = signal<Product[]>([]);
  readonly categories = signal<Category[]>([]);
  readonly pageNumber = signal(1);
  readonly pageSize = signal(10);
  readonly totalPages = signal(0);
  readonly selectedCategoryId = signal<number | undefined>(undefined);
  readonly loading = signal(false);

  ngOnInit(): void {
    this.loadProducts();
    this.loadCategories();

  }

  private loadProducts(): void {
    this.loading.set(true);

    this.productsService
      .getProducts(
        this.pageNumber(),
        this.pageSize(),
        this.selectedCategoryId()
      )
      .pipe(
        finalize(() => this.loading.set(false))
      )
      .subscribe({
        next: response => {
          this.products.set(response.items);
          this.pageNumber.set(response.pageNumber);
          this.totalPages.set(response.totalPages);
        },
        error: error => {
          console.error('Failed to load products:', error);
        }
      });
  }


  private loadCategories(): void {
    this.categoryService.getCategories()
      .subscribe({
        next: response => {
          this.categories.set(response)
        },
        error: error => {
          console.error('Failed to load categories:', error);
        }
      });
  }

  onCategoryChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;

    const categoryId = selectElement.value
      ? Number(selectElement.value)
      : undefined;

    this.selectedCategoryId.set(categoryId);

    this.pageNumber.set(1);

    this.loadProducts();
  }

  previousPage(): void {
    if (this.pageNumber() <= 1) {
      return;
    }

    this.pageNumber.update(page => page - 1);

    this.loadProducts();
  }

  nextPage(): void {
    if (this.pageNumber() >= this.totalPages()) {
      return;
    }

    this.pageNumber.update(page => page + 1);

    this.loadProducts();
  }


  readonly createProductForm = this.formBuilder.nonNullable.group(
    {

      name: ['', [Validators.required, Validators.maxLength(200)]],
      price: [0, [Validators.required, Validators.min(0.01)]],
      stockQuantity: [0, [Validators.required, Validators.min(0)]],
      categoryId: [0, [Validators.required, Validators.min(1)]]

    });

  createProduct(): void {

    if (this.createProductForm.invalid) {
      return;
    }

    const request = this.createProductForm.getRawValue();

    this.productsService.createProduct(request).subscribe({
      next: () => {

        this.createProductForm.reset({
          name: '',
          price: 0,
          stockQuantity: 0,
          categoryId: 0
        });

        this.showCreateForm.set(false);

        this.pageNumber.set(1);

        this.loadProducts();
      },

      error: error => {
        console.error('Failed to create product:', error);
      }
    });
  }

  cancelCreate(): void {
    this.createProductForm.reset({
      name: '',
      price: 0,
      stockQuantity: 0,
      categoryId: 0
    });

    this.showCreateForm.set(false);
  }

  readonly createCategoryForm = this.formBuilder.nonNullable.group({
    name: ['', [
      Validators.required,
      Validators.maxLength(100)
    ]]
  });

  createCategory(): void {
    if (this.createCategoryForm.invalid) {
      return;
    }

    const request = this.createCategoryForm.getRawValue();

    this.categoryService.createCategory(request).subscribe({
      next: () => {
        this.createCategoryForm.reset({
          name: ''
        });

        this.showCreateCategoryForm.set(false);

        this.loadCategories();
      },
      error: error => {
        console.error('Failed to create category:', error);
      }
    });
  }

  cancelCreateCategory(): void {
    this.createCategoryForm.reset({
      name: ''
    });

    this.showCreateCategoryForm.set(false);
  }
}
