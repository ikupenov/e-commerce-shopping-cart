import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs/internal/Observable';
import { first } from 'rxjs/operators';

import { ProductsService, CartService, Product, CartItem } from '@app/core';

@Component({
  selector: 'app-product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.scss']
})
export class ProductGridComponent implements OnInit {

  products$: Observable<Product[]>;
  breakpoint: number;

  constructor(private productsService: ProductsService, private cartService: CartService) { }

  ngOnInit() {
    this.products$ = this.productsService.getProducts();
    this.calculateGridBreakpoint(window.innerWidth);
  }

  onAddToCart(cartItem: CartItem) {
    this.cartService.addToCart(cartItem).pipe(
      first()
    ).subscribe();
  }

  onResize(event) {
    this.calculateGridBreakpoint(event.target.innerWidth);
  }

  private calculateGridBreakpoint(innerWidth: number) {
    if (innerWidth <= 600) {
      this.breakpoint = 1;
    } else if (innerWidth <= 700) {
      this.breakpoint = 2;
    } else if (innerWidth <= 800) {
      this.breakpoint = 3;
    } else if (innerWidth <= 1000) {
      this.breakpoint = 4;
    } else {
      this.breakpoint = 5;
    }
  }

}
