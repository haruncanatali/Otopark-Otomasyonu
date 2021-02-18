import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';
import { User } from './user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  path = "https://localhost:44320/Account/Login"
  yollanacakModel : User = new User()
  durum !: string
  loginForm:any;

  constructor(private formBuilder:FormBuilder,private httpServis:HttpClient,private router:Router,private loginServis:LoginService) { }

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm(){
    this.loginForm = this.formBuilder.group({
        KullaniciAdi : ["",Validators.required],
        Sifre : ["",Validators.required]
    })
  }


  login(form:NgForm){
    this.loginServis.login(form.value);
  }

  logOut():void{
    this.loginServis.logOut()
  }

  
}
