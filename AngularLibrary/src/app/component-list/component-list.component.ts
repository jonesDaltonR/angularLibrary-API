import { Component, OnInit, Input } from '@angular/core';
import {Book} from '../models/book';
import { BookService } from '../book.service';

@Component({
// tslint:disable-next-line: component-selector
  selector: 'component-list',
  templateUrl: './component-list.component.html',
  styleUrls: ['./component-list.component.scss']
})
export class ComponentListComponent implements OnInit {
  @Input() books : Book[];

  constructor(private book_service: BookService) {
  }

  ngOnInit() {
  }

}
