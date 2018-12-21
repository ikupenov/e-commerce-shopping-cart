import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '@app/shared';

import { ProductGridComponent } from './product-grid/product-grid.component';
import { ProductGridItemComponent } from './product-grid-item/product-grid-item.component';
import { CartComponent } from './cart/cart.component';

@NgModule({
  declarations: [ProductGridComponent, ProductGridItemComponent, CartComponent],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class ShopModule { }
