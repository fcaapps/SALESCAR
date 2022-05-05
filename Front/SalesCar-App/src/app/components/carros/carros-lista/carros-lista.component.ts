import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { CarroService } from 'src/services/carro.service';

@Component({
  selector: 'app-carros-lista',
  templateUrl: './carros-lista.component.html',
  styleUrls: ['./carros-lista.component.scss']
})
export class CarrosListaComponent implements OnInit {

  modalRef?: BsModalRef;

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

  constructor(private carroService: CarroService,
              private modalService: BsModalService,
              private toastr: ToastrService,
              private router: Router) { }

  ngOnInit() {
    this.getCarros();
  }

  public getCarros(): void {
    this.carroService.getCarros().subscribe(
      response => {
        this.carros = response,
        this.carrosFiltrados = this.carros
      },
      error => console.log(error)
    );
  }



  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Carro foi excluído com sucesso!', 'Excluído');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheCarro(id: number): void {
    this.router.navigate([`carros/detalhe/${id}`]);
  }

}
