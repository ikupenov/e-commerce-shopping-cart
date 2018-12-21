import { Component, OnInit } from '@angular/core';

import { Observable } from 'rxjs/internal/Observable';

import { ProductsService, Product } from '@app/core';

@Component({
  selector: 'app-product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.scss']
})
export class ProductGridComponent implements OnInit {

  getProducts: Observable<Product>;
  breakpoint: number;

  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.getProducts = this.productsService.getProducts();
    this.updateBreakpoint(window.innerWidth);
  }

  onAddToCart(product) {
  }

  onResize(event) {
    this.updateBreakpoint(event.target.innerWidth);
  }

  private updateBreakpoint(innerWidth: number) {
    this.breakpoint = (innerWidth <= 400) ? 1 : 6;
  }

}
