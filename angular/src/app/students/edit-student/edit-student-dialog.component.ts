import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter,
  ChangeDetectorRef,
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  StudentServiceProxy,
  CollegeServiceProxy,
  StudentDto,
  CollegeDto
} from '@shared/service-proxies/service-proxies';

@Component({
  templateUrl: 'edit-student-dialog.component.html'
})
export class EditStudentDialogComponent extends AppComponentBase
    implements OnInit {
  saving = false;
  student: StudentDto = new StudentDto();
  colleges: CollegeDto[] = [];
  id: number;

  @Output() onSave = new EventEmitter<any>();

  constructor(
      injector: Injector,
      public _studentService: StudentServiceProxy,
      public _collegeService: CollegeServiceProxy,
      public bsModalRef: BsModalRef,
      private cd: ChangeDetectorRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._studentService.get(this.id).subscribe((result: StudentDto) => {
      this.student = result;

      this._collegeService.getAll(undefined, 0, undefined).subscribe((result2) => {
        this.colleges = result2.items;
        this.cd.detectChanges();
      });

    });
  }

  save(): void {
    this.saving = true;

    this._studentService.update(this.student).subscribe(
        () => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        },
        () => {
          this.saving = false;
        }
    );
  }
}
