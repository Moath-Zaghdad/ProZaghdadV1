import { ProZaghdadV1TemplatePage } from './app.po';

describe('ProZaghdadV1 App', function() {
  let page: ProZaghdadV1TemplatePage;

  beforeEach(() => {
    page = new ProZaghdadV1TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
