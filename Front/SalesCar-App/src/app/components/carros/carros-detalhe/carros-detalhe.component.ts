import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Carro } from 'src/models/Carro';
import { CarroService } from 'src/services/carro.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';


@Component({
  selector: 'app-carros-detalhe',
  templateUrl: './carros-detalhe.component.html',
  styleUrls: ['./carros-detalhe.component.scss']
})
export class CarrosDetalheComponent implements OnInit {

  form: FormGroup | any;

  estadoSalvar = 'post';

  idParam: string | any;

  get f(): any {
    return this.form.controls;
  }

  carro = {} as Carro;

  constructor(private fb :FormBuilder,
              private router: ActivatedRoute,
              private carroService: CarroService,
              private spinner: NgxSpinnerService,
              private toastr: ToastrService,
              private router2: Router
              ) {
  }

  // public pegarId(id: number): any {
  //   return '';
  // }

  public carregarCarro(): void {
    const carroIdParam = this.router.snapshot.paramMap.get('id');

    console.log('carroidparam:'+carroIdParam);

    this.idParam = carroIdParam;

    this.idParam = carroIdParam;

    if (carroIdParam !== null) {

      this.spinner.show();

      this.estadoSalvar = 'put';

      this.carroService.getCarroById(+carroIdParam).subscribe(
        (carro: Carro) => {
          this.carro = {...carro};
          console.log(this.carro);
          this.form.patchValue(this.carro);
        },
        (error: any) => {
          console.error(error);
        },
        () => {},
      );
    }
  }

  ngOnInit(): void {
    this.carregarCarro();
    this.validation();
  }

  public validation() {
    this.form = this.fb.group({
      descricao: ['', Validators.required],
      cor: ['',Validators.required],
      anoFabricacao: ['',Validators.required],
      anoModelo: ['',Validators.required],
      marca: ['',Validators.required],
    });
  }

  public salvarAlteracao(): void {
    this.spinner.show();
    if (this.form.valid) {

      console.log(this.estadoSalvar);

      if (this.estadoSalvar == 'post') {
        console.log('Entrou no post');
        this.carro = {...this.form.value};
        this.carroService.postCarro(this.carro).subscribe(
          () => this.toastr.success('Carro salvo com sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.show();
            this.toastr.success('Erro ao salvar carro!', 'Erro')
          },
          () => this.spinner.hide()
        )
      }
      else {
        console.log('Entrou no put');
        this.carro = {id: this.idParam, ...this.form.value};
        console.log(this.carro);
        this.carroService.putCarro(this.idParam, this.carro).subscribe(
          () => this.toastr.success('Carro salvo com sucesso!', 'Sucesso'),
          (error: any) => {
            console.error(error);
            this.spinner.show();
            this.toastr.success('Carro ao salvar evento!', 'Erro')
          },
          () => this.spinner.hide()
        )
      }
    }
    this.router2.navigate([`/carros/lista`]);
  }

}
