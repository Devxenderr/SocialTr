using System.Collections.Generic;

namespace SocialTrading.Locale
{
    public class LangRU : ILang
    {
        public string EmptyFill                     { get { return "Это поле обязательно к заполнению"; } }
        public string NotValidData                  { get { return "Невалидные данные"; } }
        public string Posts                         { get { return "Новости"; } }
        public string Deals                         { get { return "Сделки"; }}
        public string Favorites                     { get { return "Избранные"; } }
        public string Notification                  { get { return "Уведомления"; } }
        public string PasswordRecovery              { get { return "Введите Вашу почту"; } }
        public string UserAgreementNotChecked       { get { return "Пользовательское соглашение не принято!"; } }
        public string ButtonNext                    { get { return "Далее"; } }
        public string RegNameHint                   { get { return "Имя"; } }
        public string RegLastNameHint               { get { return "Фамилия"; } }
        public string RegNameTextView               { get { return "Введите Ваше имя и фамилию"; } }
        public string RegEmailTextView              { get { return "Введите Вашу почту"; } }
        public string PasswordHint                  { get { return "Пароль"; } }
        public string RegPassConfirmHint            { get { return "Подтвердите пароль"; } }
        public string RegPassTextView               { get { return "Установите пароль"; } }
        public string RegUserAgreementTextView      { get { return "Нажимая \"Зарегистрироваться\", Вы соглашаетесь с условиями нашего "; } }
        public string RegUserAgreementLink          { get { return "Пользовательского соглашения."; } }
        public string RegButton                     { get { return "Зарегистрироваться"; } }
        public string EmailHint                     { get { return "Почта"; } }
        public string ForgetPasswordLink            { get { return "Забыли пароль?"; } }
        public string LogInButton                   { get { return "Войти"; } }
        public string FacebookButton                { get { return "Войти через Facebook"; } }
        public string AcceptButton                  { get { return "Принимаю"; } }
        public string DeclineButton                 { get { return "Не принимаю"; } }
        public string ToolsButton                   { get { return "ИНСТРУМЕНТЫ"; } }
        public string PriceLabel                    { get { return "Цена"; } }
        public string EnterCommentLabel             { get { return ", Вы рекомендуете зарабатывать на покупке или продаже (выберите инструмент)..."; } }
        public string AddPostButton                 { get { return "Добавить пост"; } }
        public string AttachedImageNone             { get { return "Прикреплено 0 картинок"; } }
        public string AttachedImageOne              { get { return "Прикреплена 1 картинка"; } }
        public string None                          { get { return "Выбрать"; } }
        public string Buy                           { get { return "Купить"; } }
        public string Sell                          { get { return "Продать"; } }
        public string Public                        { get { return "Публичный"; } }
        public string Private                       { get { return "Приватный"; } }
        public string AuthActivityTitle             { get { return "Авторизация"; } }
        public string RegActivityTitle              { get { return "Регистрация"; } }
        public string ForgotPassActivityTitle       { get { return "Восстановление пароля"; } }
        public string CreatePostActivityTitle       { get { return "Создать пост"; } }
        public string UpdatePostActivityTitle       { get { return "Обновить пост"; } }
        public string PublishButton                 { get { return "Опубликовать"; } }
        public string ShowEmailsAlertTitle          { get { return "Выберите Вашу почту"; } }
        public string Minute15                      { get { return "15м"; } }
        public string Minute30                      { get { return "30м"; } }
        public string Hour1                         { get { return "1ч"; } }
        public string Hour4                         { get { return "4ч"; } }
        public string Hour8                         { get { return "8ч"; } }
        public string Hour24                        { get { return "24ч"; } }
        public string Week1                         { get { return "1 неделя"; } }
        public string Other                         { get { return "Другое"; } }
        public string BuySellTextView               { get { return "Я рекомендую"; } }
        public string TimeTextView                  { get { return "Время прогноза"; } }
        public string AccessModeTextView            { get { return "Доступ"; } }
        public string CreatePostToolsActivityTitle  { get { return "Инструменты"; } }
        public string ForecastTime                  { get { return "Срок действия:"; } }
        public string Offline                       { get { return "Offline"; } }
        public string Online                        { get { return "Online"; } }
        public string Difference                    { get { return "Разница:"; } }
        public string Margin                        { get { return "Маржа"; } }
        public string PnL                           { get { return "P&L"; } }
        public string Pips                          { get { return "pips"; } }
        
        public string DealsPost                     { get { return "Сделки:"; } }
        public string ReadMore                      { get { return "Читать дальше"; } }
        public string OptionsHeader                 { get { return "Опции"; } }
		public string UpdatePost                    { get { return "Обновить"; } }
		public string DeletePost                    { get { return "Удалить"; } }
		public string ShortLabel                    { get { return "Short"; } }
		public string LongLabel                     { get { return "Long"; } }
        public string DeletePostMessage             { get { return "Вы уверены что хотите удалить пост?"; } }
        public string DeletePostTitle               { get { return "Удаление поста"; } }
        public string DeletePostErrorMessage        { get { return "Ошибка при удалении поста"; } }
        public string DeletePostSuccessMessage      { get { return "Пост удален"; } }
        public string ForecastTimeDay               { get { return "д"; } }
        public string Edit                          { get { return "Редактировать"; } }
        public string RegPhoneNumberHeader          { get { return "Укажите свой номер телефона"; } }
        public string RegPhoneNumberButtonSkip      { get { return "Пропустить"; } }
        public string RegPhoneNumberHint            { get { return "Телефон"; } }
        public string RecommendAlertTitle           { get { return "Вы рекомендуете"; } }
        public string ForecastTimeAlertTitle        { get { return "Время прогноза"; } }
        public string AccessModeAlertTitle          { get { return "Доступ"; } }
        public string AnotherForecastTimeAlertTitle { get { return "Выберите время прогноза"; } }
        public string RegPhoneCountryHint           { get { return "Код"; } }
        public string AuthSlogan                    { get { return "Первая социальная сеть для инвесторов"; } }
        public string AuthNoAccount                 { get { return "Нет аккаунта?"; } }
        public string AuthSocialEnter               { get { return "Войти через соц. сети"; } }
        public string MinutesEnding                 { get { return "м"; } }
        public string MinutesEndingCreatedAt        { get { return "мин"; } }
        public string HourEnding                    { get { return "ч"; } }
        public string ForecastTimeEnd               { get { return "0d 00:00:00"; } }
        public string CreateNow                     { get { return "Сейчас"; } }

        
		public string RegNameFeatureText            { get { return "Общайтесь\nс профессионалами рынка"; } }
		public string RegEmailFeatureText           { get { return "Используйте прогнозы\nуспешных трейдеров"; } }
		public string RegPhoneFeatureText           { get { return "Получайте информацию\nпо всем активам"; } }
		public string RegPassFeatureText            { get { return "Зарабатывайте\nв один клик!"; } }
        public string ForgotPassMsgRecovery         { get { return "! Инструкция по восстановлению пароля отправлена на почту пользователя, "; } }
        public string ForgotPassButton              { get { return "Восстановить пароль"; } }

        public List<string> MonthsCreatedAt         { get { return new List<string> { "Янв", "Фев", "Марта", "Апр", "Мая", "Июня", "Июля", "Авг", "Сент", "Окт", "Нояб", "Дек" }; } }
        public List<string> Months                  { get { return new List<string> { "Янв", "Фев", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Сент", "Окт", "Нояб", "Дек" }; } }
        public List<string> Hours                   { get { return new List<string> { "00 ч", "01 ч", "02 ч", "03 ч", "04 ч", "05 ч", "06 ч", "07 ч", "08 ч", "09 ч",
            "10 ч", "11 ч", "12 ч", "13 ч", "14 ч", "15 ч", "16 ч", "17 ч", "18 ч", "19 ч", "20 ч", "21 ч", "22 ч", "23 ч" }; } }

        //MoreOptions
        public string ViewMyProfile                 { get { return "Посмотреть мой профиль"; } }
        public string Settings                      { get { return "Настройки"; } }
		public string MoreOptionsLogOut             { get { return "Выйти"; } }
		public string MoreOptionsContacts           { get { return "Контактные данные"; } }
		public string MoreOptionsProfileSettings    { get { return "Настройки профиля"; } }
        public string MoreOprionsToolbarTitle       { get { return "Настройки"; } }

        // IAlert
        public string OK                            { get { return "Ок"; } }
        public string Cancel                        { get { return "Отмена"; } }
        public string Error                         { get { return "Ошибка"; } }
        public string NoConnection                  { get { return "Нет подключения к Интернету"; } }
        public string NoResponse                    { get { return "Нет ответа от сервера"; } }
        public string NotFound                      { get { return "Результата по заданому запросу нет"; } }
        public string ServiceUnavailable            { get { return "Сервер недоступен. Попробуйте позже"; } }
        public string UnknownError                  { get { return "Неизвестная ошибка"; } }
        public string LogoutAlert                   { get { return "Вы уверены, что хотите выйти?"; } }
        public string Yes                           { get { return "Да"; } }
        public string No                            { get { return "Нет"; } }
        public string UnprocessableEntity           { get { return "Неизвестная сущность"; } }
        public string Unauthorized                  { get { return "Вы не авторизовались!"; } }
        public string BadRequest                    { get { return "Неверная передаваемая сущность!"; } }
        public string BadToken                      { get { return "Время текущей сессии истекло. Для продолжения работы выполните вход ещё раз"; } }

        // RA
        public string AuthError                     { get { return "Ошибка авторизации!"; } }
        public string FacebookAuthError             { get { return "Отсутствует email на вашем аккаунте Facebook. Заполните его или разрешите отправку"; } }
        public string RegSuccess                    { get { return "Для подтверждения регистрации проверьте вашу почту "; } }
        public string UserDataError                 { get { return "Пользователь с такими данными уже существует!"; } }
        public string PassNotMatch                  { get { return "Пароль не совпадает"; } }
        public string PasswordRecoverySuccess       { get { return "Письмо отправлено. Пожалуйста, следуйте инструкциям в письме."; } }
        public string PasswordRecoveryError         { get { return "Пользователь не существует или не может быть восстановлен."; } }
        public string RegPasswordIsTooShort         { get { return "Задайте другой пароль"; } }
        public string RegEmailIsInvalid             { get { return "Введите действительный эл. адрес."; }}
        public string RegFirstNameIsIncorrect       { get { return "Введите корректное имя"; } }
        public string RegLastNameIsIncorrect        { get { return "Введите корректную фамилию"; } }
        public string RegError                      { get { return "Ошибка регистрации"; } }

        // CreatePost
        public string CreatePostSuccess             { get { return "Пост успешно создан!"; } }
        public string UpdatePostSuccess             { get { return "Пост успешно обновлен!"; } }
        public string CreatePostBadRequest          { get { return "Ошибка в запросе!"; } }
        public string CreatePostUnauthorized        { get { return "Вы не авторизовались!"; } }
        public string CreatePostUnprocessableEntity { get { return "Неверная передаваемая сущность!"; } }
        public string TooLargeImage                 { get { return "Файл слишком большой. Максимальный размер - 2 MB"; } }

        // Post
        public string Like                          { get { return "Лайк"; } }
        public string Comments                      { get { return "Комментарии"; } }
        public string ShareWith                     { get { return "Поделиться"; } }
        public string LikeError                     { get { return "Вы не авторизовались!"; } }
        public string DetailedPostTitle             { get { return "Пост"; } }
        public string PostsTitle                    { get { return ""; } }
        public string PostsButtonCreatePost         { get { return "Создать пост"; } }

        //MoreOptions - ProfileCell
        public string YourProfile                   { get { return "Ваш профиль"; } }
        
        //ToolBar
        public string ToolbarTitle                  { get { return "Настройки"; } }

        //EditContact
        public string EditContactToolbarTitle       { get { return "Контактные данные"; } }
        public string EditContactEmail              { get { return "Почта"; } }
        public string EditContactSkype              { get { return "Skype"; } }
        public string EditContactCountry            { get { return "Страна"; } }
        public string EditContactCity               { get { return "Город"; } }
        public string EditContactPhone              { get { return "Телефон"; } }
        public string EditContactSave               { get { return "Сохранить изменения"; } }
        public string EditContactCancel             { get { return "Отмена"; } }
        public string EditContactAlertOk            { get { return "Ок"; } }
        public string EditContactAlertSuccess       { get { return "Изменения сохранены"; } }
        public string EditContactAlertFail          { get { return "Не удалось сохранить изменения"; } }
        public string EditContactCountries          { get { return ResourceCountries.CountriesDictionary; } }
        public string EditContactCountriesToolbar   { get { return "Выбор страны"; } }

        //EditProfile
        public string EditProfileNameTitle                     { get { return "Имя"; } }
        public string EditProfileLastnameTitle                 { get { return "Фамилия"; } }
        public string EditProfileStatusTitle                   { get { return "Статус"; } }
        public string EditProfileSaveButtonTitle               { get { return "СОХРАНИТЬ ИЗМЕНЕНИЯ"; } }
        public string EditProfileCancelButtonTitle             { get { return "ОТМЕНА"; } }
        public string EditProfileToolbarTitle                  { get { return "Настройки профиля"; } }
        public string EditProfileAlertSuccess                  { get { return "Изменения сохранены"; } }
        public string EditProfileAlertFail                     { get { return "Ошибка сохранения"; } }
    }
}
