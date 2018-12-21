import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-product-grid-item',
  templateUrl: './product-grid-item.component.html',
  styleUrls: ['./product-grid-item.component.scss']
})
export class ProductGridItemComponent {

  @Input() id: string;
  @Input() name: string;
  @Input() price: number;
  @Input() imageUrl: string;

  @Output() addToCart = new EventEmitter<ProductEventResult>();

  quantity = 1;

  onAddToCartClick() {
    const eventResult: ProductEventResult = {
      id: this.id,
      quantity: this.quantity
    };

    this.addToCart.emit(eventResult);
  }

}

export interface ProductEventResult {
  id: string;
  quantity: number;
}
