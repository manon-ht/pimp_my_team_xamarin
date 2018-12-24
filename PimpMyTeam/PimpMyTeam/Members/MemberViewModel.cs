using System;
namespace PimpMyTeam
{
    public class MemberViewModel : ViewModelBase
    {
        Member member;
        public Member Member
        {
            set { SetProperty(ref member, value); }
            get { return member; }
        }

        String firstName;
        public String FirstName
        {
            set
            {
                Member.FirstName = value;
                SetProperty(ref firstName, value);
            }
            get
            {
                if (firstName == null)
                {
                    return Member.FirstName;
                }
                return firstName;
            }
        }

        String email;
        public String Email
        {
            set
            {
                Member.Email = value;
                SetProperty(ref email, value);
            }
            get
            {
                if (email == null)
                {
                    return Member.Email;
                }
                return email;
            }
        }

        String lastName;
        public String LastName
        {
            set
            {
                Member.LastName = value;
                SetProperty(ref lastName, value);
            }
            get
            {
                if (lastName == null)
                {
                    return Member.LastName;
                }
                return lastName;
            }
        }

        String phoneNumber;
        public String PhoneNumber
        {
            set
            {
                Member.PhoneNumber = value;
                SetProperty(ref phoneNumber, value);
            }
            get
            {
                if (phoneNumber == null)
                {
                    return Member.PhoneNumber;
                }
                return phoneNumber;
            }
        }


        public MemberViewModel()
        {
            member = new Member();
        }
   
    }
}
