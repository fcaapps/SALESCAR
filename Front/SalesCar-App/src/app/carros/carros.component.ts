import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-carros',
  templateUrl: './carros.component.html',
  styleUrls: ['./carros.component.scss']
})
export class CarrosComponent implements OnInit {

  public carros: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getCarros();
  }

  public getCarros(): void {
    this.http.get('https://localhost:5001/api/Carros').subscribe(
      response => this.carros = response,
      error => console.log(error)
    );
  }

}
