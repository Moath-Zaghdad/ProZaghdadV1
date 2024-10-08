import { ChangeDetectorRef, Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
    StudentServiceProxy,
    StudentDto,
    StudentDtoPagedResultDto,
    CollegeDto,
    CollegeServiceProxy,
} from '@shared/service-proxies/service-proxies';
import { CreateStudentDialogComponent } from './create-student/create-student-dialog.component';
import { EditStudentDialogComponent } from './edit-student/edit-student-dialog.component';

class PagedStudentsRequestDto extends PagedRequestDto {
    keyword: string;
    isActive: boolean | null;
}

@Component({
    templateUrl: './students.component.html',
    animations: [appModuleAnimation()]
})

export class StudentsComponent extends PagedListingComponentBase<StudentDto> {
    students: StudentDto[] = [];
    keyword = '';
    isActive: boolean | null;
    colleges: { [key: number]: string } = {};
    advancedFiltersVisible = false;

    constructor(
        injector: Injector,
        private _studentService: StudentServiceProxy,
        private _collegeService: CollegeServiceProxy,
        private _modalService: BsModalService,
        cd: ChangeDetectorRef
    ) {
        super(injector, cd);
    }

    protected list(
        request: PagedStudentsRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
        request.keyword = this.keyword;
        request.isActive = this.isActive;

        this._studentService
            .getAll(
                request.keyword,
                request.isActive,
                request.skipCount,
                request.maxResultCount
            )
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: StudentDtoPagedResultDto) => {
                this.students = result.items;
                this.showPaging(result, pageNumber);

                const collegeIds = [...new Set(this.students.map(student => student.collegeId))]
                for(const collegId of collegeIds) {
                    this._collegeService.get(collegId).subscribe(college => {
                        this.colleges[college.id] = college.name
                        this.cd.detectChanges();
                    });
                }
                console.log(this.colleges, this.students);

            });
    }

    delete(student: StudentDto): void {
        abp.message.confirm(
            this.l('StudentDeleteWarningMessage', student.firstName),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._studentService
                        .delete(student.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.refresh();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    createStudent(): void {
        this.showCreateOrEditStudentDialog();
    }

    editStudent(student: StudentDto): void {
        this.showCreateOrEditStudentDialog(student.id);
    }

    showCreateOrEditStudentDialog(id?: number): void {
        let createOrEditStudentDialog: BsModalRef;
        if (!id) {
            createOrEditStudentDialog = this._modalService.show(
                CreateStudentDialogComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditStudentDialog = this._modalService.show(
                EditStudentDialogComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: id,
                    },
                }
            );
        }

        createOrEditStudentDialog.content.onSave.subscribe(() => {
            this.refresh();
        });
    }

    clearFilters(): void {
        this.keyword = '';
        this.isActive = undefined;
        this.getDataPage(1);
    }
}
