import { Component, OnInit } from '@angular/core';

import { Subject } from 'rxjs';
import { map, first } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';

import { CartService, CartItem, Cart } from '@app/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  cartItems$ = new Subject<CartItem[]>();

  constructor(private cartService: CartService) { }

  ngOnInit() {
    const cart$ = this.cartService.getCart();
    this.emitCartItems(cart$);
  }

  onClearCartButtonClick() {
    this.cartService.clearCart().pipe(
      first()
    ).subscribe(() => this.cartItems$.next([]));
  }

  onContinueButtonClick() {
    alert('Task for another day :)');
  }

  onRemoveFromCart(cartItem: CartItem) {
    const cart$ = this.cartService.removeFromCart(cartItem);
    this.emitCartItems(cart$);
  }

  onQuantityChange(cartItem: CartItem) {
    const cart$ = this.cartService.updateCartItem(cartItem);
    this.emitCartItems(cart$);
  }

  private emitCartItems($cart: Observable<Cart>) {
    $cart.pipe(
      first(),
      map(c => c.cartItems)
    ).subscribe(cartItems => this.cartItems$.next(cartItems));
  }

}
