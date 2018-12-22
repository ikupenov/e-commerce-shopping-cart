import { Component, Input, Output, EventEmitter } from '@angular/core';

import { Product, CartItem } from '@app/core';

@Component({
  selector: 'app-product-grid-item',
  templateUrl: './product-grid-item.component.html',
  styleUrls: ['./product-grid-item.component.scss']
})
export class ProductGridItemComponent {

  @Input() id: string;
  @Input() name: string;
  @Input() price: number;
  @Input() imageUrl: string;

  @Output() addToCart = new EventEmitter<CartItem>();

  quantity = 1;

  onAddToCartClick() {
    const product = new Product();
    product.id = this.id;
    product.name = this.name;
    product.price = this.price;
    product.imageUrl = this.imageUrl;

    const eventResult: CartItem = {
      product: product,
      quantity: this.quantity
    };

    this.addToCart.emit(eventResult);
  }

}
