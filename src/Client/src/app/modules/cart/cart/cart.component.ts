import { Component, OnInit } from '@angular/core';

import { Subject } from 'rxjs';
import { map, first } from 'rxjs/operators';

import { CartService, CartItem } from '@app/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  cartItems$ = new Subject<CartItem[]>();

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.cartService.getCart().pipe(
      first(),
      map(c => c.cartItems)
    ).subscribe(cartItems => this.cartItems$.next(cartItems));
  }

  onClearButtonClick() {
    this.cartService.clearCart().pipe(
      first()
    ).subscribe(() => this.cartItems$.next([]));
  }

  onRemoveFromCart(cartItem: CartItem) {
    this.cartService.removeFromCart(cartItem).pipe(
      first(),
      map(c => c.cartItems)
    ).subscribe(cartItems => this.cartItems$.next(cartItems));
  }

}
