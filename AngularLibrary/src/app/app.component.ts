import { BookService } from './book.service';
import { Book } from './models/book';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'gr-library';
  books : Book[];
  constructor(private book_service : BookService) {
    this.book_service.getBooks()
    .subscribe(
      data => this.handleSuccess(data),
      error => console.log(error)
      );
  }

  receiveQuery($event)
  {
    this.book_service.searchBooks($event)
      .subscribe(
        data => this.handleSuccess(data),
        error => console.log(error)
        );
  }
  handleSuccess(data)
  {
    console.log(data);
    this.books = data;
  }
}
