import { Arac } from "./arac";

export class Konum{
    id:number|undefined;
    kat:number|undefined;
    yer!:string;
    cephe:string|undefined;
    durum:boolean|undefined;
    arac!:Arac;
}