import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Carro } from 'src/models/Carro';

@Injectable()
export class CarroService {

  baseURL = 'https://localhost:5001/api/Carros';

  constructor(private http: HttpClient) { }

  public getCarros(): Observable<Carro[]> {
    return this.http
      .get<Carro[]>(this.baseURL)
  }

  public getCarroById(id: number): Observable<Carro> {
    return this.http
      .get<Carro>(`${this.baseURL}/${id}`)
  }

  public getCarroByDescricao(descricao: string): Observable<Carro[]> {
    return this.http
      .get<Carro[]>(`${this.baseURL}/${descricao}/descricao`)
  }

  public postCarro(carro: Carro): Observable<Carro> {
    return this.http
      .post<Carro>(this.baseURL, carro)
  }

  public putCarro(id: number, carro: Carro): Observable<Carro> {
    return this.http
      .put<Carro>(`${this.baseURL}/${id}`, carro)
  }

  public deleteCarros(id: number): Observable<any> {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
