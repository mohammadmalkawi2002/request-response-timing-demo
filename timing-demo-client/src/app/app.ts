import { Component, inject, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ProductService } from './features/products/services/ProductService/product.service';
import { CategoryService } from './features/products/services/CategoryService/category.service';

@Component({
  imports: [RouterOutlet],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('timing-demo-client');
  


  }



