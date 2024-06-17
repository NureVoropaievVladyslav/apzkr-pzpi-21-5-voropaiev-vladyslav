import { Component } from '@angular/core';
import { UsersService } from '../core/services/users.service';
import { User } from '../core/models/user';
import { DatePipe } from '@angular/common';
import { jsPDF } from 'jspdf';
import autoTable from 'jspdf-autotable';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.sass'],
  providers: [DatePipe]
})
export class UserListComponent {
  users: User[] = [];

  constructor(private usersService: UsersService, public translate: TranslateService) {
    translate.addLangs(['en', 'ua']);
    translate.setDefaultLang('en');

    const browserLang = translate.getBrowserLang();
    // @ts-ignore
    translate.use(browserLang.match(/en|ua/) ? browserLang : 'en');
  }

  ngOnInit() {
    this.usersService.get().subscribe(users => {
      this.users = users;
    });
  }

  saveToPdf() {
    const doc = new jsPDF('l', 'pt', 'a4', true);
    autoTable(doc, {
      html: '#users-table',
      didParseCell: (data) => {
        if (data.section === 'body' && data.column.index === data.table.columns.length - 1) {
          data.cell.text = [];
        }
      },
      theme: 'striped',
    });
    const date = new Date();
    doc.save(date + ' users.pdf');
  }

  export() {
    this.usersService.export().subscribe(data => {
      const blob = new Blob([JSON.stringify(data)], { type: 'application/json' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      const date = new Date();
      a.download = date + ' users.json';
      a.click();
    });
  }

  import() {
    const input = document.createElement('input');
    input.type = 'file';
    input.accept = '.json';
    input.onchange = () => {
      const file = input.files?.item(0);
      if (file) {
        const reader = new FileReader();
        reader.onload = () => {
          this.usersService.import(reader.result as string).subscribe(() => {
            window.location.reload();
          });
        };
        reader.readAsText(file);
      }
    };
    input.click();
  }

  makeAdmin(id: string) {
    this.usersService.makeAdmin(id).subscribe(() => {
      window.location.reload();
    });
  }

  delete(id: string) {
    this.usersService.delete(id).subscribe(() => {
      window.location.reload();
    });
  }
}
