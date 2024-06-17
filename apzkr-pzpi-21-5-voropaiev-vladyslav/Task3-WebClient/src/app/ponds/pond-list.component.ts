import { Component } from '@angular/core';
import { jsPDF } from 'jspdf';
import autoTable from 'jspdf-autotable';
import { PondsService } from '../core/services/ponds.service';
import { FishSpecies, Pond } from '../core/models/pond';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-pond-list',
  templateUrl: './pond-list.component.html',
  styleUrls: ['./pond-list.component.sass'],
  providers: [DatePipe]
})
export class PondListComponent {
  ponds: Pond[] = [];

  constructor(private pondsService: PondsService) { }

  ngOnInit() {
    this.pondsService.get().subscribe(users => {
      this.ponds = users;
    });
  }

  saveToPdf() {
    const doc = new jsPDF('l', 'pt', 'a4', true);
    autoTable(doc, {
      html: '#ponds-table',
      didParseCell: (data) => {
        if (data.section === 'body' && data.column.index === data.table.columns.length - 1) {
          data.cell.text = [];
        }
      },
      theme: 'striped',
    });
    const date = new Date();
    doc.save(date + ' ponds.pdf');
  }

  export() {
    this.pondsService.export().subscribe(data => {
      const blob = new Blob([JSON.stringify(data)], { type: 'application/json' });
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      const date = new Date();
      a.download = date + ' ponds.json';
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
          this.pondsService.import(reader.result as string).subscribe(() => {
            window.location.reload();
          });
        };
        reader.readAsText(file);
      }
    };
    input.click();
  }

  delete(id: string) {
    this.pondsService.delete(id).subscribe(() => {
      window.location.reload();
    });
  }

  protected readonly FishSpecies = FishSpecies;
}
