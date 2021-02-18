import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { TanitimComponent } from './tanitim/tanitim.component';
import {HttpClientModule} from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AracEkleComponent } from './arac-ekle/arac-ekle.component';
import { LoginService } from './services/login.service';
import { LoginGuard } from './login/login.guard';
import { AracDetayComponent } from './arac-detay/arac-detay.component';
import { AracService } from './services/arac.service';
import { HomeService } from './services/home.service';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    TanitimComponent,
    HomeComponent,
    LoginComponent,
    AracEkleComponent,
    AracDetayComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxChartsModule,
    BrowserAnimationsModule
  ],
  providers: [LoginService,LoginGuard,AracService,HomeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
