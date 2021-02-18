import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  path = "https://localhost:44320/Account/Login"
  loggedIn : any

  constructor(private httpServis:HttpClient,private router:Router) { }

  login(formData:any){
    return this.httpServis.post(this.path,formData).subscribe(
      (res:any)=>{
        localStorage.setItem('isLogged',res.token)
        this.loggedIn = true
        this.router.navigateByUrl('/index')
      },
      err=>{
        if(err.status == 400){
            alert('Giriş başarısız oldu.')
        }
      }
    )
  }

  isLoggedIn():boolean{
    return this.loggedIn
  }

  logOut(){
    localStorage.removeItem('isLogged')
    this.loggedIn = false
    this.router.navigateByUrl('/login')
  }

  
}
