import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AracDetayComponent } from './arac-detay/arac-detay.component';
import { AracEkleComponent } from './arac-ekle/arac-ekle.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { LoginGuard } from './login/login.guard';
import { LoginService } from './services/login.service';

const routes: Routes = [
  {path:"login",component:LoginComponent},
  {path:"index",component:HomeComponent,canActivate:[LoginGuard]},
  {path:"aracEkle",component:AracEkleComponent,canActivate:[LoginGuard]},
  {path:"",redirectTo:"index",pathMatch:"full"},
  {path:"detay",component:AracDetayComponent,canActivate:[LoginGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
