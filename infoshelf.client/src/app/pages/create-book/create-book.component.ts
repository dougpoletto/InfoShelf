import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BookDto } from '../../models/BookDto';
import { BookService } from '../../services/BookService';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrl: './create-book.component.css'
})
export class CreateBookComponent {
  public formBook = new FormGroup({
    titulo: new FormControl("", Validators.required),
    autor: new FormControl("", Validators.required),
    genero: new FormControl("", Validators.required),
    ano: new FormControl("", Validators.required),
  });

  constructor(private router: Router, private bookService: BookService, private toastr: ToastrService) { }

  async save() {
    if (!this.formBook.valid) {
      this.toastr.warning("Campos inválidos ou não informados!");
      return;
    }

    let book = new BookDto({
      ano: parseInt(this.formBook.controls["ano"].value ?? ""),
      autor: this.formBook.controls["autor"].value ?? "",
      genero: this.formBook.controls["genero"].value ?? "",
      titulo: this.formBook.controls["titulo"].value ?? ""
    });

    let response = await this.bookService.postBook(book);
    if (!response.success) {
      this.toastr.error("Ocorreu um erro ao cadastrar o livro. Tente novamente!");
      return;
    } else {
      this.toastr.success("Livro cadastrado com sucesso!");
      this.router.navigate([""]);
    }
  }

  cancel() {
    this.router.navigate([""]);
  }
}
