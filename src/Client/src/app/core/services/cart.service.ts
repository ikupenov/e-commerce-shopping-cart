import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { of } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';

import { Cart, CartItem } from '../models';

/**
 * The ID is hardcoded due to testing purposes.
 * Should be replaced with the current user's actual ID/username.
 */
const userId = '0ef27a5d-b9f2-4470-96d2-7123fab03460';
const serviceUrl = `/users/${userId}/cart`;

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private httpClient: HttpClient) { }

  getCart(): Observable<Cart> {
    return this.httpClient.get<Cart>(serviceUrl);
  }

  clearCart(): Observable<void> {
    return this.httpClient.delete(serviceUrl).pipe(
      switchMap(_ => of(null))
    );
  }

  addToCart(cartItem: CartItem): Observable<Cart> {
    return this.httpClient.post<Cart>(`${serviceUrl}/add`, cartItem);
  }

  removeFromCart(cartItem: CartItem): Observable<Cart> {
    return this.httpClient.post<Cart>(`${serviceUrl}/remove`, cartItem);
  }

}
