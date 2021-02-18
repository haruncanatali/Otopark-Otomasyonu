import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(private loginServis:LoginService) { }

  ngOnInit(): void {
  }

  durum():boolean{
    if(this.loginServis.isLoggedIn()){
      return true
    }
    else{
      return false
    }
  }

}
