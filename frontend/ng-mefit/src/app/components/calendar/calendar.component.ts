import { Component, Input, OnInit, TemplateRef, ViewChild, ViewEncapsulation } from '@angular/core';
import { CalendarEvent, CalendarEventTimesChangedEvent, CalendarMonthViewBeforeRenderEvent, CalendarView } from 'angular-calendar';
import { isSameDay, isSameMonth } from 'date-fns';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class CalendarComponent implements OnInit {
  @ViewChild('modalContent', { static: true }) modalContent: TemplateRef<any> | undefined;

  constructor(private modal: NgbModal) { }

  events: CalendarEvent[] = [];

  @Input() endDate: Date = new Date();
  @Input() programName: string = "";

  ngOnInit(): void {
    this.events.push({
      start: new Date(),
      end: new Date(this.endDate),
      title: this.programName,
      allDay: true,
    })
  }

  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();


  activeDayIsOpen: boolean = false;

  modalData: {
    action: string;
    event: CalendarEvent;
  } | undefined;

  refresh = new Subject<void>();

  handleEvent(action: string, event: CalendarEvent): void {
    this.modalData = { event, action };
    this.modal.open(this.modalContent, { size: 'lg' });
  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
    if (isSameMonth(date, this.viewDate)) {
      if (
        (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
        events.length === 0
      ) {
        this.activeDayIsOpen = false;
      } else {
        this.activeDayIsOpen = true;
      }
      this.viewDate = date;
    }
  }

  beforeMonthViewRender(renderEvent: CalendarMonthViewBeforeRenderEvent): void {
    const today = new Date();
    today.setHours(0,0,0,0);
    const eDate : Date = new Date(this.endDate);

    renderEvent.body.forEach((day) => {
      if (day.date > today && day.date <= eDate && day.inMonth) {
        day.cssClass = 'bg-info';
      }
    });
  }

  eventTimesChanged({
    event,
    newStart,
    newEnd,
  }: CalendarEventTimesChangedEvent): void {
    this.events = this.events.map((iEvent) => {
      if (iEvent === event) {
        return {
          ...event,
          start: newStart,
          end: newEnd,
        };
      }
      return iEvent;
    });
    this.handleEvent('Dropped or resized', event);
  }
  closeOpenMonthViewDay() {
    this.activeDayIsOpen = false;
  }

}
