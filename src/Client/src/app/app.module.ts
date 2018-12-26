import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from '@app/app.component';
import { HeaderComponent, FooterComponent } from '@app/layouts';
import { AppRoutingModule } from '@app/app-routing.module';
import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { ShopModule, CartModule } from '@app/modules';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CoreModule.forRoot(),
    SharedModule,
    AppRoutingModule,
    BrowserModule,
    ShopModule,
    CartModule,
    NoopAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
