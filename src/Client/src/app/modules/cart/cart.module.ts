import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedModule } from '@app/shared';

import { CartComponent } from './cart/cart.component';
import { CartItemComponent } from './cart-item/cart-item.component';

@NgModule({
  declarations: [CartComponent, CartItemComponent],
  imports: [
    CommonModule,
    SharedModule
  ]
})
export class CartModule { }
