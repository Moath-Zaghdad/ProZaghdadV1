import { ChangeDetectorRef, Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto,
} from '@shared/paged-listing-component-base';
import {
    CollegeServiceProxy,
    CollegeDto,
    CollegeDtoPagedResultDto,
} from '@shared/service-proxies/service-proxies';
import { CreateCollegeDialogComponent } from './create-college/create-college-dialog.component';
import { EditCollegeDialogComponent } from './edit-college/edit-college-dialog.component';

class PagedCollegesRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './colleges.component.html',
    animations: [appModuleAnimation()]
})

export class CollegesComponent extends PagedListingComponentBase<CollegeDto> {
    colleges: CollegeDto[] = [];
    keyword = '';

    constructor(
        injector: Injector,
        private _collegeService: CollegeServiceProxy,
        private _modalService: BsModalService,
        cd: ChangeDetectorRef
    ) {
        super(injector, cd);
    }

    protected list(
        request: PagedCollegesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {
        request.keyword = this.keyword;

        this._collegeService
            .getAll(
                request.keyword,
                request.skipCount,
                request.maxResultCount
            )
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: CollegeDtoPagedResultDto) => {
                this.colleges = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    delete(college: CollegeDto): void {
        abp.message.confirm(
            this.l('CollegeDeleteWarningMessage', college.name),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._collegeService
                        .delete(college.id)
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

    createCollege(): void {
        this.showCreateOrEditCollegeDialog();
    }

    editCollege(college: CollegeDto): void {
        this.showCreateOrEditCollegeDialog(college.id);
    }

    showCreateOrEditCollegeDialog(id?: number): void {
        let createOrEditCollegeDialog: BsModalRef;
        if (!id) {
            createOrEditCollegeDialog = this._modalService.show(
                CreateCollegeDialogComponent,
                {
                    class: 'modal-lg',
                }
            );
        } else {
            createOrEditCollegeDialog = this._modalService.show(
                EditCollegeDialogComponent,
                {
                    class: 'modal-lg',
                    initialState: {
                        id: id,
                    },
                }
            );
        }

        createOrEditCollegeDialog.content.onSave.subscribe(() => {
            this.refresh();
        });
    }

    clearFilters(): void {
        this.keyword = '';
        this.getDataPage(1);
    }
}
