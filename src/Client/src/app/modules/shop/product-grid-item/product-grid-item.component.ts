import { Component, Input, Output, EventEmitter } from '@angular/core';

import { Product, CartItem } from '@app/core';

@Component({
  selector: 'app-product-grid-item',
  templateUrl: './product-grid-item.component.html',
  styleUrls: ['./product-grid-item.component.scss']
})
export class ProductGridItemComponent {

  @Input() product: Product;

  @Output() addToCart = new EventEmitter<CartItem>();

  quantity = 1;

  onAddToCartClick() {
    const cartItem: CartItem = {
      product: this.product,
      quantity: this.quantity
    };

    this.addToCart.emit(cartItem);
  }

}
