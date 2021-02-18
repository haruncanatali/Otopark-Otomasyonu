import { Fatura } from "./fatura";

export class Arac{
    id:number|undefined;
    tcKimlikNo:string|undefined;
    ad:string|undefined;
    soyad:string|undefined;
    telefonNo:string|undefined;
    plaka:string|undefined;
    marka:string|undefined;
    model:string|undefined;
    renk:string|undefined;
    konumId:string|undefined;
    fatura:Fatura = new Fatura()

}
