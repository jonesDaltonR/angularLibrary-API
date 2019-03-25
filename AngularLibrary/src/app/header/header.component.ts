import { Component, OnInit, Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  query : string;
  @Output() searchBooks = new EventEmitter<string>();
  constructor() { }

  ngOnInit() {
  }
  search()
  {
    console.log(this.query);
    this.searchBooks.emit(this.query)
  }

}
