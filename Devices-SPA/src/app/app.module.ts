import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { DeviceListComponent } from './devices/device-list/device-list.component';
import { DeviceDetailComponent } from './devices/device-detail/device-detail.component';

import { AuthGuard } from './_guards/auth.guard';


import { DeviceResolver } from './_resolvers/device.resolver';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule} from '@angular/material/icon';
import { MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { DeviceDetailsResolver } from './_resolvers/device-details.resolver';


@NgModule({
  declarations: [		
    AppComponent,
      HomeComponent,
      NavComponent,
      DeviceListComponent,
      DeviceDetailComponent
   ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatProgressSpinnerModule
  ],
  providers: [
    AuthGuard,
    DeviceResolver,
    DeviceDetailsResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
