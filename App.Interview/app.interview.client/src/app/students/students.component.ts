import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { ActivatedRoute, Router } from '@angular/router';

interface Staff {
  staffId: number;
  firstName: string;
  lastName: string;
}

interface Course {
  courseId: number;
  courseName: string;
  staffId: number;
  staff?: Staff;
}

interface Roster {
  // Adding Roster interface as it's referenced in Student
  // Add more properties as needed when we know more about the Roster model
  id: number;
}

interface Student {
  studentId: number;
  firstName: string;
  lastName: string;
  rosters: Roster[];
}

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatSidenavModule, MatListModule],
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  students: Student[] = [];
  selectedStudent: Student | null = null;
  courses: Course[] = [];
  loading = true;
  error = '';
  displayedColumns: string[] = ['studentId', 'firstName', 'lastName'];
  courseColumns: string[] = ['courseId', 'courseName', 'staffName'];
  
  constructor(
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    this.fetchStudents();
    
    // Subscribe to route params
    this.route.params.subscribe(params => {
      const studentId = params['id'];
      if (studentId) {
        // Find and select the student once data is loaded
        if (this.students.length > 0) {
          const student = this.students.find(s => s.studentId === +studentId);
          if (student) {
            this.selectStudent(student);
          }
        }
      }
    });
  }

  fetchStudents() {
    this.http.get<Student[]>('/api/students').subscribe({
      next: (students) => {
        this.students = students.map(student => ({
          ...student,
          // Ensure all required properties exist even if backend doesn't provide them
          firstName: student.firstName || '',
          lastName: student.lastName || '',
          rosters: student.rosters || []
        }));
        this.loading = false;

        // Check for route parameter after loading
        const studentId = this.route.snapshot.params['id'];
        if (studentId) {
          const student = this.students.find(s => s.studentId === +studentId);
          if (student) {
            this.selectStudent(student);
          }
        }
      },
      error: (error) => {
        this.error = 'Failed to load students';
        this.loading = false;
        console.error('Error fetching students:', error);
      }
    });
  }

  selectStudent(student: Student) {
    this.selectedStudent = student;
    this.router.navigate(['/students', student.studentId]);
    this.fetchStudentCourses(student.studentId);
  }

  fetchStudentCourses(studentId: number) {
    this.http.get<Course[]>(`/api/students/${studentId}/courses`).subscribe({
      next: (courses) => {
        this.courses = courses;
      },
      error: (error) => {
        console.error('Error fetching courses:', error);
        this.error = 'Failed to load courses';
      }
    });
  }
}
