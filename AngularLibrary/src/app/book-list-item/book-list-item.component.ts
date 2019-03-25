import { Component, OnInit, Input } from '@angular/core';
import {Book} from '../models/book';

@Component({
  selector: 'book-list-item',
  templateUrl: './book-list-item.component.html',
  styleUrls: ['./book-list-item.component.scss']
})
export class BookListItemComponent implements OnInit {
  @Input() book: Book;

  constructor() {}

  ngOnInit() {
  }

}
