import { Component, Input, Output, EventEmitter } from '@angular/core';

import { CartItem } from '@app/core';

@Component({
  selector: 'app-cart-item',
  templateUrl: './cart-item.component.html',
  styleUrls: ['./cart-item.component.scss']
})
export class CartItemComponent {

  @Input() cartItem: CartItem;

  @Output() removeFromCart = new EventEmitter<CartItem>();

  onRemoveButtonClick() {
    this.removeFromCart.emit(this.cartItem);
  }

}
