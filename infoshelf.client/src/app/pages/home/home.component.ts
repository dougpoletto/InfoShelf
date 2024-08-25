import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { BookDto } from '../../models/BookDto';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from '../../services/BookService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public booksColumns: string[] = ["id", "titulo", "autor", "genero", "ano"];
  public listBooks: MatTableDataSource<BookDto[]> = new MatTableDataSource<BookDto[]>([]);

  constructor(private activatedRoute: ActivatedRoute, private bookService: BookService, private router: Router) { }

  async ngOnInit() {
    let response = await this.bookService.getListBooks();
    console.log(response.success);
    if (response.success) {
      this.listBooks = new MatTableDataSource(response.response);
    }
  }

  async createBook() {
    this.router.navigate(["createBook"]);
  }
}
