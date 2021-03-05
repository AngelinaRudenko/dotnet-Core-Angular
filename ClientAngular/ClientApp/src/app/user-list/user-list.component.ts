import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { User, Users } from '../app.interfaces';
import { AppService } from '../app.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  subscribtion?: Subscription;
  users?: Array<User>;
  totalUsers?: string;
  selectLimit = ['10', '20', '30', '50'];
  paginate = { limit: '10', page: '0' };

  constructor(private appService: AppService) { }

  ngOnInit(): void {
    this.addSubscribe();
  }

  onChangeSelect(): void {
    this.paginate.page = '0';
    this.addSubscribe();
  }

  addSubscribe(): void {
    this.subscribtion = this.appService.getUsers(this.paginate.limit, this.paginate.page).subscribe((value) => {
      this.users = value.data;
      this.totalUsers = value.total;
      this.subscribtion?.unsubscribe();
    });
  }

  onClickIncrease(): void {
    let temp = (+(this.paginate.page) + 1);
    if (temp < this.getLastPage()) {
      this.paginate.page = temp.toString();
      this.addSubscribe();
    }
    else {
      this.onClickLast()
    }
  }

  onClickDecrease(): void {
    let temp = +(this.paginate.page) - 1;
    if (temp > 0) {
      this.paginate.page = temp.toString();
      this.addSubscribe();
    }
    else {
      this.onClickFirst();
    }
  }

  onClickFirst(): void {
    this.paginate.page = '0';
    this.addSubscribe();
  }

  onClickLast(): void {
    this.paginate.page = this.getLastPage().toString();
    this.addSubscribe();
  }

  getLastPage(): number {
    //+() the same as Number()
    return Math.ceil((+(this.totalUsers ?? '0') / +(this.paginate.limit)) - 1);
  }
}
