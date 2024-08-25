import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { BookDto } from '../../models/BookDto';
import { BookService } from '../../services/BookService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  public booksColumns: string[] = ["id", "titulo", "autor", "genero", "ano"];
  public listBooks: MatTableDataSource<BookDto[]> = new MatTableDataSource<BookDto[]>([]);

  constructor(private bookService: BookService, private router: Router) { }

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  async ngOnInit() {
    let response = await this.bookService.getListBooks();
    if (response.success) {
      this.listBooks = new MatTableDataSource(response.response);
      this.listBooks.paginator = this.paginator;
    }
  }

  async createBook() {
    this.router.navigate(["createBook"]);
  }
}
