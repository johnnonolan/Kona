Then /^I should see "([^\"]*)" listed under "([^\"]*)"$/ do |product, area|
  within get_div_id(area) do |products|
    products.should contain(product)
  end
end

Then /^I should not see "([^\"]*)" listed under "([^\"]*)"$/ do |product, area|
  within get_div_id(area) do |products|
    products.should_not contain(product) #This does not work with Selenium
  end
end

Then /^I should see "([^\"]*)" listed$/ do |product|
  response.should contain(product)
end

def get_div_id(id)
  "#" + id.downcase.underscore
end