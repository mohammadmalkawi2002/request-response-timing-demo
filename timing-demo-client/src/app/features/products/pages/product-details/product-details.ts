import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Product } from '../../models/products.models';
import { ProductService } from '../../services/ProductService/product.service';

@Component({
  selector: 'app-product-details',
  imports: [RouterLink],
  templateUrl: './product-details.html',
  styleUrl: './product-details.css'
})
export class ProductDetails implements OnInit {

  private readonly route = inject(ActivatedRoute);
  private readonly productService = inject(ProductService)

  readonly product = signal<Product | null>(null);

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.productService.getProductById(id).subscribe({
      next: response => {
        this.product.set(response);
      },
      error: error => {
        console.error('Failed to load product:', error);
      }
    });
  }
}
