namespace SimplonHubApi.Utilities
{
    public static class HardCode
    {
        // Roles
        public static Guid ROLE_SUPER_ADMIN => Guid.Parse("bde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid ROLE_ADMIN => Guid.Parse("4a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid ROLE_TEACHER => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid ROLE_STUDENT => Guid.Parse("87a0a5ed-c7bb-4394-a163-7ed7560b4a01");

        // Genders
        public static Guid GENDER_MALE => Guid.Parse("1de5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid GENDER_FEMALE => Guid.Parse("2a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid GENDER_OTHER => Guid.Parse("3ba0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Statuses Account
        public static Guid STATUS_PENDING => Guid.Parse("4de5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid STATUS_CONFIRMED => Guid.Parse("5a5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid STATUS_BANNED => Guid.Parse("6ba0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Statuses Booking
        public static Guid BOOKING_PENDING => Guid.Parse("7de5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid BOOKING_CONFIRMED => Guid.Parse("8a5eaf2f-0496-4035-a4b7-9210da39501c");

        // Levels
        public static Guid LEVEL_BEGINNER => Guid.Parse("9de5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid LEVEL_INTERMEDIATE => Guid.Parse("aa5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid LEVEL_ADVANCED => Guid.Parse("bba0a5ed-c7bb-4394-a163-7ed7560b3703");

        // Categories
        public static Guid CATEGORY_SOFT => Guid.Parse("cde5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid CATEGORY_TECHNICS => Guid.Parse("da5eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid CATEGORY_FRONT => Guid.Parse("eba0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid CATEGORY_BACK => Guid.Parse("f1f1f997-c392-4aac-bef0-fc8acaf109ec");

        // Languages
        public static Guid LANGUAGE_FRENCH => Guid.Parse("11e5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid LANGUAGE_ENGLISH => Guid.Parse("022eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid LANGUAGE_ARAB => Guid.Parse("33a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid LANGUAGE_SPANISH => Guid.Parse("44f1f997-c392-4aac-bef0-fc8acaf109ec");

        // ProgrammingLanguages
        public static Guid LANGUAGE_JS => Guid.Parse("55e5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid LANGUAGE_JAVA => Guid.Parse("066eaf2f-0496-4035-a4b7-9210da39501c");
        public static Guid LANGUAGE_CSHARP => Guid.Parse("77a0a5ed-c7bb-4394-a163-7ed7560b3703");
        public static Guid LANGUAGE_CPP => Guid.Parse("88f1f997-c392-4aac-bef0-fc8acaf109ec");

        // type slots
        public static Guid SLOT_TYPE_VISIO => Guid.Parse("99e5556b-562d-431f-9ff9-d31a5f5cb8c5");
        public static Guid SLOT_TYPE_PRESENTIAL => Guid.Parse("0aaeaf2f-0496-4035-a4b7-9210da39501c");
    }
}
