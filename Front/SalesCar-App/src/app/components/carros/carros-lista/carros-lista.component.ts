import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
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
  public carroId = 0;
  public carroDescricao = '';

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
              private spinner: NgxSpinnerService,
              private toastr: ToastrService,
              private router: Router) { }

  ngOnInit() {
    this.getCarros();

    /** spinner starts on init */
    this.spinner.show();

    setTimeout(() => {
      /** spinner ends after 5 seconds */
      this.spinner.hide();
    }, 5000);
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

  openModal(event: any, template: TemplateRef<any>, carroId: number, carroDescricao: string) {
    event.stopPropagation();
    this.carroId = carroId;
    this.carroDescricao = carroDescricao;
    console.log(carroId + ' - ' + carroDescricao);
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.carroService.deleteCarros(this.carroId).subscribe(
      (result: string) => {
        console.log(result);
        this.toastr.success(
          'O Carro foi deletado com Sucesso.',
          'Deletado!'
        );
        this.spinner.hide();
        this.getCarros();
      },
      (error: any) => {
        console.error(error);
        this.toastr.error(
          `Erro ao tentar deletar o carro ${this.carroId}`,
          'Erro'
        );
        this.spinner.hide();
      },
      () => this.spinner.hide()
    );
    //this.toastr.success('O Carro foi excluído com sucesso!', 'Excluído');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheCarro(id: number): void {
    this.router.navigate([`carros/detalhe/${id}`]);
  }

}
