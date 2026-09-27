
export interface Product {
  id: Number;
  name: string;
  price: Number;
  stockQuantity: Number;
  categoryId: Number;
  categoryName: string;


}


export interface CreateProductRequest {
  name: string;
  price: number;
  stockQuantity: number;
  categoryId: number;

}
