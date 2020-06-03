import {ExcelComponent} from '@core/ExcelComponent';
import {createTable} from '@/components/table/table.template';

export class Table extends ExcelComponent {
  nameClass() {
    return 'excel__table'
  }
  toHTML() {
    return createTable();
  }
}
