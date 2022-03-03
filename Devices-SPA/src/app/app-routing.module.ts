import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { DeviceListComponent } from './devices/device-list/device-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { DeviceResolver } from './_resolvers/device.resolver';
import { DeviceDetailComponent } from './devices/device-detail/device-detail.component';
import { DeviceDetailsResolver } from './_resolvers/device-details.resolver';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
      path: '',
      runGuardsAndResolvers: 'always',
      canActivate: [AuthGuard],
      children: [
          { path: 'devices', component: DeviceListComponent,
              resolve: { devices: DeviceResolver } },
          { path: 'devicedetails/:id', component: DeviceDetailComponent,
              resolve: { user: DeviceDetailsResolver } },
      ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
