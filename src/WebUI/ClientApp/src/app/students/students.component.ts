import { Component, TemplateRef } from '@angular/core';
import { StudentDto,
         BookDto,
         StudentsClient,
         BooksClient,
         CreateStudentCommand,
         UpdateStudentCommand} from '../web-api-client';
import { faPlus, faEllipsisH } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
         

@Component({
    selector: 'app-students-component',
    templateUrl: './students.component.html',
    styleUrls: ['./students.component.scss']
})

export class StudentsComponent {

    debug = false;

    selectedStudent: StudentDto;
    selectedBook: BookDto;

    newStudentEditor: any = {};
    studentOptionsEditor: any = {};
    bookDetailsEditor: any = {};

    newStudentModalRef: BsModalRef;
    studentOptionsModalRef: BsModalRef;
    deleteStudentModalRef: BsModalRef;
    bookDetailsModalRef: BsModalRef;

    faPlus = faPlus;
    faEllipsisH = faEllipsisH;
    students: StudentDto[];

    constructor(private studentsClient: StudentsClient, private modalService: BsModalService) {
        
        
        studentsClient.get().subscribe(
            result => {
                this.students = result;
                if (this.students.length) {
                    this.selectedStudent = this.students[0];
                }
            },
            error => console.error(error)
        );
    }

    // Students
    bookCount(student: StudentDto): number {
        return student.books.length;
    }

    showNewStudentModal(template: TemplateRef<any>): void {
        this.newStudentModalRef = this.modalService.show(template);
        setTimeout(() => document.getElementById("firstName").focus(), 250);
    }

    newStudentCancelled(): void {
        this.newStudentModalRef.hide();
        this.newStudentEditor = {};
    }

    addStudent(): void {
        let student = StudentDto.fromJS({
            id: 0,
            firstName: this.newStudentEditor.firstName,
            middleName: this.newStudentEditor.middleName,
            lastName: this.newStudentEditor.lastName,
            email: this.newStudentEditor.email,
            books: [],
        });

        this.studentsClient.create(<CreateStudentCommand>{
            firstName: this.newStudentEditor.firstName,
            middleName: this.newStudentEditor.middleName,
            lastName: this.newStudentEditor.lastName,
            email: this.newStudentEditor.email,
        }).subscribe(
            result => {
                student.id = result;
                this.students.push(student);
                this.selectedStudent = student;
                this.newStudentModalRef.hide();
                this.newStudentEditor = {};
            },
            error => {
                let errors = JSON.parse(error.response);
                console.log(errors);
                if (errors && errors.Title) {
                    this.newStudentEditor.error = errors.Title[0];
                }

                setTimeout(() => document.getElementById("firstName").focus(), 250);
            }
        );
    }

    showStudentOptionsModal(template: TemplateRef<any>) {
        this.studentOptionsEditor = {
            id: this.selectedStudent.id,
            firstName: this.selectedStudent.firstName,
            middleName: this.selectedStudent.middleName,
            lastName: this.selectedStudent.lastName,
            email: this.selectedStudent.email,
        };

        this.studentOptionsModalRef = this.modalService.show(template);
    }

    updateStudentOptions() {
        this.studentsClient.update(this.selectedStudent.id, UpdateStudentCommand.fromJS(this.studentOptionsEditor))
            .subscribe(
                () => {
                    this.selectedStudent.firstName = this.studentOptionsEditor.firstName,
                    this.selectedStudent.middleName = this.studentOptionsEditor.middleName,
                    this.selectedStudent.lastName = this.studentOptionsEditor.lastName,
                    this.selectedStudent.email = this.studentOptionsEditor.email,
                    this.studentOptionsModalRef.hide();
                    this.studentOptionsEditor = {};
                },
                error => console.error(error)
            );
    }

    confirmDeleteStudent(template: TemplateRef<any>) {
        this.studentOptionsModalRef.hide();
        this.deleteStudentModalRef = this.modalService.show(template);
    }

    deleteStudentConfirmed(): void {
        this.studentsClient.delete(this.selectedStudent.id).subscribe(
            () => {
                this.deleteStudentModalRef.hide();
                this.students = this.students.filter(t => t.id != this.selectedStudent.id)
                this.selectedStudent = this.students.length ? this.students[0] : null;
            },
            error => console.error(error)
        );
    }

    // Books

    showBookDetailsModal(template: TemplateRef<any>, book: BookDto): void {
        this.selectedBook = book;
        this.bookDetailsEditor = {
            ...this.selectedBook
        };

        this.bookDetailsModalRef = this.modalService.show(template);
    }

    
}
