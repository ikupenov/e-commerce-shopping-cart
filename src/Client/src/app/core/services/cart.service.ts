import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs/internal/Observable';

import { Cart, CartItem } from '../models';

/**
 * The ID is hardcoded due to testing purposes.
 * Should be replaced with the current user's actual ID/username.
 */
const serviceUrl = '/users/0ef27a5d-b9f2-4470-96d2-7123fab03460/cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(private httpClient: HttpClient) { }

  getCart(): Observable<Cart> {
    return this.httpClient.get<Cart>(serviceUrl);
  }

  addToCart(cartItem: CartItem): Observable<Cart> {
    return this.httpClient.post<Cart>(`${serviceUrl}/add`, cartItem);
  }

}
