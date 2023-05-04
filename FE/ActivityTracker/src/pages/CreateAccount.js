import React from 'react';
import {SafeAreaView, View, Text} from 'react-native';
import {TextInput, Button} from 'react-native-paper';

function CreateAccount({navigation}) {
  return (
    <SafeAreaView>
      <View>
        <View>
          <Text>Username</Text>
          <TextInput />
        </View>
        <View>
          <Text>Password</Text>
          <TextInput />
        </View>
        <View>
          <Button
            mode="contained"
            style={{backgroundColor: 'gray'}}
            onPress={() => navigation.navigate('SignIn')}>
            Back
          </Button>
          <Button mode="contained" style={{backgroundColor: 'gray'}}>
            Register
          </Button>
        </View>
      </View>
    </SafeAreaView>
  );
}

export default CreateAccount;
