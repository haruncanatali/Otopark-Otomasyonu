import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { LoginService } from "../services/login.service";

@Injectable()

export class LoginGuard implements CanActivate{

    constructor(private loginServis:LoginService,private router:Router){}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
        let logged = this.loginServis.isLoggedIn()
        if(logged){
            return true
        }
        else{
            this.router.navigateByUrl('/login')
            return false
        }
    }

}