import { Component, OnInit } from '@angular/core';
import { FormBuilder, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { parse } from 'path';
import { element } from 'protractor';
import { Arac } from '../services/arac';
import { AracService } from '../services/arac.service';
import { Fatura } from '../services/fatura';
import { HomeService } from '../services/home.service';
import { Konum } from '../services/konum';

@Component({
  selector: 'app-arac-detay',
  templateUrl: './arac-detay.component.html',
  styleUrls: ['./arac-detay.component.css']
})
export class AracDetayComponent implements OnInit {

  modelArac : Arac = new Arac()
  bosKonumlar : Konum[] = []
  konum : Konum = new Konum()
  aracId = ""
  faturaDurumu = true
  yeniFatura : Arac = new Arac()



  constructor(private aracServisi:AracService,private homeServisi:HomeService,private router:Router) {
    this.aracId = this.aracServisi.aracId
    this.yeniFatura.fatura.aracId = Number(this.aracId)
  }

  durumDondur():boolean{
    return this.faturaDurumu
  }

  ngOnInit(): void {


    if(this.aracId!=""){
      this.aracServisi.aracGetir(this.aracId).subscribe(
        (data:Arac)=>{
          this.modelArac = data
        }
      );
      this.aracServisi.aracGetir(this.aracId).subscribe(
        (data:Arac)=>{
          if(data.fatura == null){
            this.faturaDurumu = false
          }
        }
      );      
    }
    this.homeServisi.BosKonumlariGetir().subscribe(data=>{
      this.bosKonumlar = data
    });
    if(this.aracId!=""){
      this.homeServisi.KonumGetir(this.aracId).subscribe(data=>{
        this.konum = data
      });
    }
  }

  aracDetayGuncelle(form:NgForm){

    if(this.modelArac.konumId == null){
      this.modelArac.konumId = this.konum.id!.toString()
    }

    this.aracServisi.aracGuncelle(this.modelArac).subscribe(
      (res:any)=>{
        this.router.navigateByUrl('/index')
      },
      err=>{
        if(err.status == 400){
          alert("Güncelleme İşlemi Hatalı Oldu")
        }
      }
    )
  }

  aracCikisFonk(x:number=-1){
    this.aracServisi.aracCikisYap(x).subscribe(
      (res:any)=>{
        this.router.navigateByUrl('/index')
      },
      err=>{
        if(err.status == 400){
          alert('Silme işlemi başarısız oldu.');
        }
      }
    )
  }

  aracFaturaGuncelle(form:NgForm){
    

    if(this.faturaDurumu == false){ // ekleme


      this.aracServisi.aracFaturaEkleGuncelle(this.yeniFatura,this.faturaDurumu).subscribe(
        (res:any)=>{
          this.router.navigateByUrl('/index')
        },
        err=>{
          alert('Fatura Ekleme/Güncelleme işleminde hata meydana geldi.')
        }
      )
    }
    else{ // güncelleme
      this.faturaDurumu = true
      this.aracServisi.aracFaturaEkleGuncelle(this.modelArac,this.faturaDurumu).subscribe(
        (res:any)=>{
          this.router.navigateByUrl('/index')
        },
        err=>{
          alert('Fatura Ekleme/Güncelleme işleminde hata meydana geldi.')
        }
      )
    }
    

    
  }

  getCurrentModel() { 
    return JSON.stringify(this.yeniFatura.fatura); 
  }

}
