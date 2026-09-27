import { Routes } from '@angular/router';
import { ProductsList } from './features/products/pages/products-list/products-list';
import { ProductDetails } from './features/products/pages/product-details/product-details';

export const routes: Routes = [
  {
    path: 'products',
    component: ProductsList
  },
  {
    path: 'products/:id',
    component: ProductDetails
  },

  {
    path: '',
    redirectTo: 'products',
    pathMatch: 'full'
  }
];
