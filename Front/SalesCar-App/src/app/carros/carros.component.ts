import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-carros',
  templateUrl: './carros.component.html',
  styleUrls: ['./carros.component.scss']
})
export class CarrosComponent implements OnInit {

  public carros: any = [];

  public carrosFiltrados: any = [];

  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.carrosFiltrados = this.filtroLista ? this.filtrarCarros(this.filtroLista) : this.carros;
  }

  filtrarCarros(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.carros.filter(
      (carro: any) => carro.descricao.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCarros();
  }

  public getCarros(): void {
    this.http.get('https://localhost:5001/api/Carros').subscribe(
      response => {
        this.carros = response,
        this.carrosFiltrados = this.carros
      },
      error => console.log(error)
    );
  }

}
