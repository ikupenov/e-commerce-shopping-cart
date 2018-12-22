import { Component, OnInit } from '@angular/core';

import { Observable, from } from 'rxjs';
import { map } from 'rxjs/operators';

import { CartService, CartItem } from '@app/core';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  cartItems$: Observable<CartItem[]>;

  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.cartItems$ = this.cartService.getCart().pipe(
      map(c => c.cartItems)
    );
  }

}
